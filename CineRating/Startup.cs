﻿using CineRating.Models;
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

            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Agente'
            if (!roleManager.RoleExists("Gestores")) {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Gestores";
                roleManager.Create(role);
            }

            // criar a Role 'Agente'
            if (!roleManager.RoleExists("Administradores")) {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administradores";
                roleManager.Create(role);
            }


            // criar um utilizador 'Agente'
            var user = new ApplicationUser();
            user.UserName = "rafa@mail.com";
            user.Email = "rafa@mail.pt";
            // user.Nome = "Luís Freitas";
            string userPWD = "Aa_12345";
            var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Agente-
            if (chkUser.Succeeded) {
                var result1 = userManager.AddToRole(user.Id, "Administradores");
            }
        }

    }
}
