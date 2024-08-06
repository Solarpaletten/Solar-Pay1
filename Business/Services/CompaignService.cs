using Business.IServices;
using Data.Entities;
using Data.Entities.Common;
using DataAccess.Repository;
using DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CompaignService : ICompaignService
    {
        private readonly IRepository<AdCompaign> repository;
        private readonly IRepository<AdCompaignBid> adCompaignBidRepositry;
        private readonly IUnitofWork unitofWork;

        public CompaignService(IRepository<AdCompaign> _repository, 
            IRepository<AdCompaignBid> _adCompaignBidRepositry, IUnitofWork _unitofWork)
        {
            repository = _repository;
            adCompaignBidRepositry = _adCompaignBidRepositry;
            unitofWork = _unitofWork;
        }
        public AdCompaign AddCompaign(AdCompaign compaign)
        {
            this.repository.Add(compaign);
            this.unitofWork.saveChanges();
            return compaign;
        }

        public int DeleteCompaign(Guid id)
        {
            this.repository.Delete(id);
            return this.unitofWork.saveChanges();
        }

        public AdCompaign GetCompaignById(Guid id)
        {
            return this.repository.GetById(id);
        }

        public int UpdateCompaign(AdCompaign compaign)
        {
            this.repository.Update(compaign);
            return this.unitofWork.saveChanges();
        }

        public int PlaceAdCompaignBid(AdCompaignBid adCompaignBid)
        {
            this.adCompaignBidRepositry.Add(adCompaignBid);
            return this.unitofWork.saveChanges();
        }

        public AdCompaignBid GetAdCompaignBid(Guid Id)
        {
            return this.adCompaignBidRepositry.GetById(Id);
        }
        public List<AdCompaignBid> GetAllCampaignBidsByInfluencerId(string infuencerId)
        {
            return this.adCompaignBidRepositry.GetAll().Where(x=>x.InfulencerId==infuencerId).ToList();
        }

        public int UpdateAdCompaignBid(AdCompaignBid adCompaignBid)
        {
            this.adCompaignBidRepositry.Update(adCompaignBid);
            return this.unitofWork.saveChanges();
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            countries.Add(new Country() { CountryName = "Afghanistan" });
            countries.Add(new Country() { CountryName = "Åland Islands" });
            countries.Add(new Country() { CountryName = "Albania" });
            countries.Add(new Country() { CountryName = "Algeria" });
            countries.Add(new Country() { CountryName = "American Samoa" });
            countries.Add(new Country() { CountryName = "Andorra" });
            countries.Add(new Country() { CountryName = "Angola" });
            countries.Add(new Country() { CountryName = "Anguilla" });
            countries.Add(new Country() { CountryName = "Antarctica" });
            countries.Add(new Country() { CountryName = "Antigua and Barbuda" });
            countries.Add(new Country() { CountryName = "Argentina" });
            countries.Add(new Country() { CountryName = "Armenia" });
            countries.Add(new Country() { CountryName = "Aruba" });
            countries.Add(new Country() { CountryName = "Australia" });
            countries.Add(new Country() { CountryName = "Austria" });
            countries.Add(new Country() { CountryName = "Azerbaijan" });
            countries.Add(new Country() { CountryName = "Bahamas" });
            countries.Add(new Country() { CountryName = "Bahrain" });
            countries.Add(new Country() { CountryName = "Bangladesh" });
            countries.Add(new Country() { CountryName = "Barbados" });
            countries.Add(new Country() { CountryName = "Belarus" });
            countries.Add(new Country() { CountryName = "Belgium" });
            countries.Add(new Country() { CountryName = "Belize" });
            countries.Add(new Country() { CountryName = "Benin" });
            countries.Add(new Country() { CountryName = "Bermuda" });
            countries.Add(new Country() { CountryName = "Bhutan" });
            countries.Add(new Country() { CountryName = "Bolivia" });
            countries.Add(new Country() { CountryName = "Bosnia and Herzegovina" });
            countries.Add(new Country() { CountryName = "Botswana" });
            countries.Add(new Country() { CountryName = "Bouvet Island" });
            countries.Add(new Country() { CountryName = "Brazil" });
            countries.Add(new Country() { CountryName = "British Indian Ocean Territory" });
            countries.Add(new Country() { CountryName = "Brunei Darussalam" });
            countries.Add(new Country() { CountryName = "Bulgaria" });
            countries.Add(new Country() { CountryName = "Burkina Faso" });
            countries.Add(new Country() { CountryName = "Burundi" });
            countries.Add(new Country() { CountryName = "Cambodia" });
            countries.Add(new Country() { CountryName = "Cameroon" });
            countries.Add(new Country() { CountryName = "Canada" });
            countries.Add(new Country() { CountryName = "Cape Verde" });
            countries.Add(new Country() { CountryName = "Cayman Islands" });
            countries.Add(new Country() { CountryName = "Central African Republic" });
            countries.Add(new Country() { CountryName = "Chad" });
            countries.Add(new Country() { CountryName = "Chile" });
            countries.Add(new Country() { CountryName = "China" });
            countries.Add(new Country() { CountryName = "Christmas Island" });
            countries.Add(new Country() { CountryName = "Cocos (Keeling) Islands" });
            countries.Add(new Country() { CountryName = "Colombia" });
            countries.Add(new Country() { CountryName = "Comoros" });
            countries.Add(new Country() { CountryName = "Congo" });
            countries.Add(new Country() { CountryName = "Congo, The Democratic Republic of The" });
            countries.Add(new Country() { CountryName = "Cook Islands" });
            countries.Add(new Country() { CountryName = "Costa Rica" });
            countries.Add(new Country() { CountryName = "Cote D'ivoire" });
            countries.Add(new Country() { CountryName = "Croatia" });
            countries.Add(new Country() { CountryName = "Cuba" });
            countries.Add(new Country() { CountryName = "Cyprus" });
            countries.Add(new Country() { CountryName = "Czech Republic" });
            countries.Add(new Country() { CountryName = "Denmark" });
            countries.Add(new Country() { CountryName = "Djibouti" });
            countries.Add(new Country() { CountryName = "Dominica" });
            countries.Add(new Country() { CountryName = "Dominican Republic" });
            countries.Add(new Country() { CountryName = "Ecuador" });
            countries.Add(new Country() { CountryName = "Egypt" });
            countries.Add(new Country() { CountryName = "El Salvador" });
            countries.Add(new Country() { CountryName = "Equatorial Guinea" });
            countries.Add(new Country() { CountryName = "Eritrea" });
            countries.Add(new Country() { CountryName = "Estonia" });
            countries.Add(new Country() { CountryName = "Ethiopia" });
            countries.Add(new Country() { CountryName = "Falkland Islands (Malvinas)" });
            countries.Add(new Country() { CountryName = "Faroe Islands" });
            countries.Add(new Country() { CountryName = "Fiji" });
            countries.Add(new Country() { CountryName = "Finland" });
            countries.Add(new Country() { CountryName = "France" });
            countries.Add(new Country() { CountryName = "French Guiana" });
            countries.Add(new Country() { CountryName = "French Polynesia" });
            countries.Add(new Country() { CountryName = "French Southern Territories" });
            countries.Add(new Country() { CountryName = "Gabon" });
            countries.Add(new Country() { CountryName = "Gambia" });
            countries.Add(new Country() { CountryName = "Georgia" });
            countries.Add(new Country() { CountryName = "Germany" });
            countries.Add(new Country() { CountryName = "Ghana" });
            countries.Add(new Country() { CountryName = "Gibraltar" });
            countries.Add(new Country() { CountryName = "Greece" });
            countries.Add(new Country() { CountryName = "Greenland" });
            countries.Add(new Country() { CountryName = "Grenada" });
            countries.Add(new Country() { CountryName = "Guadeloupe" });
            countries.Add(new Country() { CountryName = "Guam" });
            countries.Add(new Country() { CountryName = "Guatemala" });
            countries.Add(new Country() { CountryName = "Guernsey" });
            countries.Add(new Country() { CountryName = "Guinea" });
            countries.Add(new Country() { CountryName = "Guinea-bissau" });
            countries.Add(new Country() { CountryName = "Guyana" });
            countries.Add(new Country() { CountryName = "Haiti" });
            countries.Add(new Country() { CountryName = "Heard Island and Mcdonald Islands" });
            countries.Add(new Country() { CountryName = "Holy See (Vatican City State)" });
            countries.Add(new Country() { CountryName = "Honduras" });
            countries.Add(new Country() { CountryName = "Hong Kong" });
            countries.Add(new Country() { CountryName = "Hungary" });
            countries.Add(new Country() { CountryName = "Iceland" });
            countries.Add(new Country() { CountryName = "India" });
            countries.Add(new Country() { CountryName = "Indonesia" });
            countries.Add(new Country() { CountryName = "Iran, Islamic Republic of" });
            countries.Add(new Country() { CountryName = "Iraq" });
            countries.Add(new Country() { CountryName = "Ireland" });
            countries.Add(new Country() { CountryName = "Isle of Man" });
            countries.Add(new Country() { CountryName = "Israel" });
            countries.Add(new Country() { CountryName = "Italy" });
            countries.Add(new Country() { CountryName = "Jamaica" });
            countries.Add(new Country() { CountryName = "Japan" });
            countries.Add(new Country() { CountryName = "Jersey" });
            countries.Add(new Country() { CountryName = "Jordan" });
            countries.Add(new Country() { CountryName = "Kazakhstan" });
            countries.Add(new Country() { CountryName = "Kenya" });
            countries.Add(new Country() { CountryName = "Kiribati" });
            countries.Add(new Country() { CountryName = "Korea, Democratic People's Republic of" });
            countries.Add(new Country() { CountryName = "Korea, Republic of" });
            countries.Add(new Country() { CountryName = "Kuwait" });
            countries.Add(new Country() { CountryName = "Kyrgyzstan" });
            countries.Add(new Country() { CountryName = "Lao People's Democratic Republic" });
            countries.Add(new Country() { CountryName = "Latvia" });
            countries.Add(new Country() { CountryName = "Lebanon" });
            countries.Add(new Country() { CountryName = "Lesotho" });
            countries.Add(new Country() { CountryName = "Liberia" });
            countries.Add(new Country() { CountryName = "Libyan Arab Jamahiriya" });
            countries.Add(new Country() { CountryName = "Liechtenstein" });
            countries.Add(new Country() { CountryName = "Lithuania" });
            countries.Add(new Country() { CountryName = "Luxembourg" });
            countries.Add(new Country() { CountryName = "Macao" });
            countries.Add(new Country() { CountryName = "Macedonia, The Former Yugoslav Republic of" });
            countries.Add(new Country() { CountryName = "Madagascar" });
            countries.Add(new Country() { CountryName = "Malawi" });
            countries.Add(new Country() { CountryName = "Malaysia" });
            countries.Add(new Country() { CountryName = "Maldives" });
            countries.Add(new Country() { CountryName = "Mali" });
            countries.Add(new Country() { CountryName = "Malta" });
            countries.Add(new Country() { CountryName = "Marshall Islands" });
            countries.Add(new Country() { CountryName = "Martinique" });
            countries.Add(new Country() { CountryName = "Mauritania" });
            countries.Add(new Country() { CountryName = "Mauritius" });
            countries.Add(new Country() { CountryName = "Mayotte" });
            countries.Add(new Country() { CountryName = "Mexico" });
            countries.Add(new Country() { CountryName = "Micronesia, Federated States of" });
            countries.Add(new Country() { CountryName = "Moldova, Republic of" });
            countries.Add(new Country() { CountryName = "Monaco" });
            countries.Add(new Country() { CountryName = "Mongolia" });
            countries.Add(new Country() { CountryName = "Montenegro" });
            countries.Add(new Country() { CountryName = "Montserrat" });
            countries.Add(new Country() { CountryName = "Mozambique" });
            countries.Add(new Country() { CountryName = "Myanmar" });
            countries.Add(new Country() { CountryName = "Namibia" });
            countries.Add(new Country() { CountryName = "Nauru" });
            countries.Add(new Country() { CountryName = "Nepal" });
            countries.Add(new Country() { CountryName = "Netherlands" });
            countries.Add(new Country() { CountryName = "Netherlands Antilles" });
            countries.Add(new Country() { CountryName = "New Caledonia" });
            countries.Add(new Country() { CountryName = "New Zealand" });
            countries.Add(new Country() { CountryName = "Nicaragua" });
            countries.Add(new Country() { CountryName = "Niger" });
            countries.Add(new Country() { CountryName = "Nigeria" });
            countries.Add(new Country() { CountryName = "Niue" });
            countries.Add(new Country() { CountryName = "Norfolk Island" });
            countries.Add(new Country() { CountryName = "Northern Mariana Islands" });
            countries.Add(new Country() { CountryName = "Norway" });
            countries.Add(new Country() { CountryName = "Oman" });
            countries.Add(new Country() { CountryName = "Pakistan" });
            countries.Add(new Country() { CountryName = "Palau" });
            countries.Add(new Country() { CountryName = "Palestinian Territory, Occupied" });
            countries.Add(new Country() { CountryName = "Panama" });
            countries.Add(new Country() { CountryName = "Papua New Guinea" });
            countries.Add(new Country() { CountryName = "Paraguay" });
            countries.Add(new Country() { CountryName = "Peru" });
            countries.Add(new Country() { CountryName = "Philippines" });
            countries.Add(new Country() { CountryName = "Pitcairn" });
            countries.Add(new Country() { CountryName = "Poland" });
            countries.Add(new Country() { CountryName = "Portugal" });
            countries.Add(new Country() { CountryName = "Puerto Rico" });
            countries.Add(new Country() { CountryName = "Qatar" });
            countries.Add(new Country() { CountryName = "Reunion" });
            countries.Add(new Country() { CountryName = "Romania" });
            countries.Add(new Country() { CountryName = "Russian Federation" });
            countries.Add(new Country() { CountryName = "Rwanda" });
            countries.Add(new Country() { CountryName = "Saint Helena" });
            countries.Add(new Country() { CountryName = "Saint Kitts and Nevis" });
            countries.Add(new Country() { CountryName = "Saint Lucia" });
            countries.Add(new Country() { CountryName = "Saint Pierre and Miquelon" });
            countries.Add(new Country() { CountryName = "Saint Vincent and The Grenadines" });
            countries.Add(new Country() { CountryName = "Samoa" });
            countries.Add(new Country() { CountryName = "San Marino" });
            countries.Add(new Country() { CountryName = "Sao Tome and Principe" });
            countries.Add(new Country() { CountryName = "Saudi Arabia" });
            countries.Add(new Country() { CountryName = "Senegal" });
            countries.Add(new Country() { CountryName = "Serbia" });
            countries.Add(new Country() { CountryName = "Seychelles" });
            countries.Add(new Country() { CountryName = "Sierra Leone" });
            countries.Add(new Country() { CountryName = "Singapore" });
            countries.Add(new Country() { CountryName = "Slovakia" });
            countries.Add(new Country() { CountryName = "Slovenia" });
            countries.Add(new Country() { CountryName = "Solomon Islands" });
            countries.Add(new Country() { CountryName = "Somalia" });
            countries.Add(new Country() { CountryName = "South Africa" });
            countries.Add(new Country() { CountryName = "South Georgia and The South Sandwich Islands" });
            countries.Add(new Country() { CountryName = "Spain" });
            countries.Add(new Country() { CountryName = "Sri Lanka" });
            countries.Add(new Country() { CountryName = "Sudan" });
            countries.Add(new Country() { CountryName = "Suriname" });
            countries.Add(new Country() { CountryName = "Svalbard and Jan Mayen" });
            countries.Add(new Country() { CountryName = "Swaziland" });
            countries.Add(new Country() { CountryName = "Sweden" });
            countries.Add(new Country() { CountryName = "Switzerland" });
            countries.Add(new Country() { CountryName = "Syrian Arab Republic" });
            countries.Add(new Country() { CountryName = "Taiwan" });
            countries.Add(new Country() { CountryName = "Tajikistan" });
            countries.Add(new Country() { CountryName = "Tanzania, United Republic of" });
            countries.Add(new Country() { CountryName = "Thailand" });
            countries.Add(new Country() { CountryName = "Timor-leste" });
            countries.Add(new Country() { CountryName = "Togo" });
            countries.Add(new Country() { CountryName = "Tokelau" });
            countries.Add(new Country() { CountryName = "Tonga" });
            countries.Add(new Country() { CountryName = "Trinidad and Tobago" });
            countries.Add(new Country() { CountryName = "Tunisia" });
            countries.Add(new Country() { CountryName = "Turkey" });
            countries.Add(new Country() { CountryName = "Turkmenistan" });
            countries.Add(new Country() { CountryName = "Turks and Caicos Islands" });
            countries.Add(new Country() { CountryName = "Tuvalu" });
            countries.Add(new Country() { CountryName = "Uganda" });
            countries.Add(new Country() { CountryName = "Ukraine" });
            countries.Add(new Country() { CountryName = "United Arab Emirates" });
            countries.Add(new Country() { CountryName = "United Kingdom" });
            countries.Add(new Country() { CountryName = "United States" });
            countries.Add(new Country() { CountryName = "United States Minor Outlying Islands" });
            countries.Add(new Country() { CountryName = "Uruguay" });
            countries.Add(new Country() { CountryName = "Uzbekistan" });
            countries.Add(new Country() { CountryName = "Vanuatu" });
            countries.Add(new Country() { CountryName = "Venezuela" });
            countries.Add(new Country() { CountryName = "Viet Nam" });
            countries.Add(new Country() { CountryName = "Virgin Islands, British" });
            countries.Add(new Country() { CountryName = "Virgin Islands, U.S." });
            countries.Add(new Country() { CountryName = "Wallis and Futuna" });
            countries.Add(new Country() { CountryName = "Western Sahara" });
            countries.Add(new Country() { CountryName = "Yemen" });
            countries.Add(new Country() { CountryName = "Zambia" });
            countries.Add(new Country() { CountryName = "Zimbabwe" });
            return countries;
        }

        public List<AdCompaign> GetAllCompaigns()
        {
            return repository.GetAll().ToList();
        }
    }
}
