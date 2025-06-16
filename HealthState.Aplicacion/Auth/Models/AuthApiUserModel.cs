using System.Collections.Generic;

namespace HealthState.Aplicacion.Auth.Models
{
    public class AuthApiUserModel
    {
        public int Id { get; set; }
        public string AppCode { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string OfficeCode { get; set; }
        public string Terminal { get; set; }

        public AuthUserProfileModel Profiles { get; set; }
    }

    public class AuthUserProfileModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AuthProfileActionModel> Transactions { get; set; } = new List<AuthProfileActionModel>();
    }

    public class AuthProfileActionModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}