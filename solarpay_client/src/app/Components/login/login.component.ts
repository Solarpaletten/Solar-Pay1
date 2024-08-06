import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { IRole } from '../../core/Models/IUser';
import { AuthServiceService } from '../../core/Services/Auth/auth-service.service';
import { TokenService } from '../../core/Services/Auth/token.service';
import { NotifyService } from '../../core/Services/Notify/notify.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  success: boolean = true;
  roles:IRole[]=[];
  errorSummary?:string;
  constructor(
    private fb: FormBuilder,
    private authService: AuthServiceService,
    private tokenService: TokenService,
    private router: Router,
    private notify:NotifyService
  ) {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    console.log(this.loginForm.value);
    if (this.loginForm.valid) {
     this.authService.onLogin(this.loginForm.value).subscribe({
        next: (response) => {
          if(response.status){
            this.tokenService.setToken(response.data.jwt);
            this.router.navigate(['/dashboard']);
          }
          else{
            this.notify.Error("Invalid email or password.");
          }
        },
      });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }

  

  get email() {
    return this.loginForm.get('email') as FormControl;
  }

  get password() {
    return this.loginForm.get('password') as FormControl;
  }
}
