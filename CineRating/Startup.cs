using CineRating.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace CineRating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            iniciaAplicacao();
        }

        /// <summary>
        /// cria, caso não existam, as Roles de suporte à aplicação: Veterinario, Funcionario, Dono
        /// cria, nesse caso, também, um utilizador...
        /// </summary>
        private void iniciaAplicacao() {

            //ApplicationDbContext  db2 = new ApplicationDbContext ();

            ApplicationDbContext db = new ApplicationDbContext();
            var administradorUser = new Utilizadores();
            var gestorUser = new Utilizadores();
            var utilizadorUser = new Utilizadores();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));


            // criar a Role 'Utilizador Registado'
            if (!roleManager.RoleExists("Utilizadores")) {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Utilizadores";
                roleManager.Create(role);
            }

            // criar a Role 'Gestor'
            if (!roleManager.RoleExists("Gestores")) {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Gestores";
                roleManager.Create(role);
            }

            // criar a Role 'Administrador'
            if (!roleManager.RoleExists("Administradores")) {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administradores";
                roleManager.Create(role);
            }


            // criar um utilizador 'Administrador'
            var admin = new ApplicationUser();
            admin.UserName = "admin@mail.com";
            admin.Email = "admin@mail.com";
            string adminPWD = "Aa_12345";
            var chkAdmin = userManager.Create(admin, adminPWD);

            administradorUser.NomeUtilizador = "admin@mail.com";
            administradorUser.Nome = "Rafael Martins";

            db.Utilizadores.Add(administradorUser);

            //Adicionar o Utilizador à respetiva Role-Agente-
            if (chkAdmin.Succeeded) {
                var result1 = userManager.AddToRole(admin.Id, "Administradores");
            }


            // criar um utilizador 'Gestor'
            var gestor = new ApplicationUser();
            gestor.UserName = "gestor@mail.com";
            gestor.Email = "gestor@mail.com";
            string gestorPWD = "Aa_12345";
            var chkGestor = userManager.Create(gestor, gestorPWD);

            gestorUser.NomeUtilizador = "gestor@mail.com";
            gestorUser.Nome = "Teste Teste";

            db.Utilizadores.Add(gestorUser);


            //Adicionar o Utilizador à respetiva Role-Agente-
            if (chkGestor.Succeeded) {
                var result1 = userManager.AddToRole(gestor.Id, "Gestores");
            }


            // criar um 'Utilizador' registado
            var user = new ApplicationUser();
            user.UserName = "utilizador@mail.com";
            user.Email = "utilizador@mail.com";
            string userPWD = "Aa_12345";
            var chkUser = userManager.Create(user, userPWD);

            utilizadorUser.NomeUtilizador = "utilizador@mail.com";
            utilizadorUser.Nome = "Testee Testee";

            db.Utilizadores.Add(utilizadorUser);


            //Adicionar o Utilizador à respetiva Role-Agente-
            if (chkGestor.Succeeded) {
                var result1 = userManager.AddToRole(user.Id, "Utilizadores");
            }

        }

    }
}
