import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink ,Router} from '@angular/router';
import { IRole } from '../../core/Models/IUser';
import { AuthServiceService } from '../../core/Services/Auth/auth-service.service';
import { TokenService } from '../../core/Services/Auth/token.service';
import { error } from 'console';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {

registerForm:FormGroup;
errorSummary?:string;
constructor(private authService:AuthServiceService, private tokenService:TokenService, private router:Router){
 this.registerForm= new FormGroup({
    firstname: new FormControl('',Validators.required),
    lastname: new FormControl('',Validators.required),
    phone:new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required,Validators.email]),
    password: new FormControl('',Validators.required),
    roleid:new FormControl('',Validators.required)
  });
}

roles:IRole[]=[];

get firstname(){
  return this.registerForm.get('firstname') as FormControl;
}
get lastname(){
  return this.registerForm.get('lastname') as FormControl;
}
get phone(){
  return this.registerForm.get('phone') as FormControl;
}
get email(){
  return this.registerForm.get('email') as FormControl;
}
get password(){
  return this.registerForm.get('password') as FormControl;
}
get roleid(){
  return this.registerForm.get('roleid') as FormControl;
}

OnSubmit(){
  if(this.registerForm.valid){
  this.authService.OnRegister(this.registerForm.value).subscribe({
    next:(response)=>{
      console.log(response);
      if(response.status){
        this.errorSummary="";
      this.tokenService.setToken(response.data.jwt);
      this.router.navigate(['/home/dashboard']);
      }
      else{
        console.log(response.message);
        this.errorSummary=response.message;
      }

    },
    error:(err:Error)=>{
      console.log(err);
    }
  });
  }
}

GetRoles(){
  this.authService.GetRoles().subscribe({
    next: (response) => {
      this.roles = response.data;
    },
    error:(err:Error)=>{
      console.log(err);
    }
  });
}

ngOnInit(): void {
  this.GetRoles();
}

}
