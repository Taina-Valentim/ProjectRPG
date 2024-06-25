// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<RPGUser> _userManager;
        private readonly SignInManager<RPGUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(
            UserManager<RPGUser> userManager,
            SignInManager<RPGUser> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        
        public string Username { get; set; }

        
        [TempData]
        public string StatusMessage { get; set; }

        
        [BindProperty]
        public InputModel Input { get; set; }

        
        public class InputModel
        {
            [Required(ErrorMessage = "O campo 'E-MAIL' é obrigatório")]
            [EmailAddress(ErrorMessage = "Por favor, insira um e-mail válido")]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            public string UserName { get; set; }

            [Display(Name = "Nome de usuário")]
            [Required(ErrorMessage = "O campo 'NOME DE USUÁRIO' é obrigatório")]
            public string NomeUsuario { get; set; }

            [Display(Name = "Data de Nascimento")]
            [Required(ErrorMessage = "O campo 'DATA DE NASCIMENTO' é obrigatório")]
            public DateOnly DataNascimento { get; set; }

            
            [Display(Name = "Número de Telefone")]
            [Phone(ErrorMessage = "Por favor, insira um telefone válido")]
            [Required(ErrorMessage = "O campo 'TELEFONE' é obrigatório")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(RPGUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);

            var usuario = await _userManager.FindByEmailAsync(email);
            var dataNascimento = usuario.DataNascimento;
            var nomeUsuario = usuario.NomeUsuario;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                UserName = userName,
                DataNascimento = dataNascimento,
                NomeUsuario = nomeUsuario
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                await LoadAsync(user);
            }

            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário!\nID: '{_userManager.GetUserId(User)}'.");
            }
            //ModelState.
            if (!ModelState.IsValid)
            {
                // await LoadAsync(user);
                AlterarDados(user);
                var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
                if (Input.PhoneNumber != phoneNumber)
                {
                    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                    if (!setPhoneResult.Succeeded)
                    {
                        StatusMessage = "Erro inesperado ao tentar definir telefone.";
                        return RedirectToPage();
                    }
                }

                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Seu perfil foi atualizado";
            }
            return RedirectToPage();
        }

        public void AlterarDados(RPGUser user)
        {
            RPGUser usuario = _unitOfWork.RPGUser.Buscar(u => u.Id == user.Id);
            if (usuario == null)
            {
                NotFound($"Não foi possível carregar o usuário!\nID: '{_userManager.GetUserId(User)}'.");
            }
            usuario.PhoneNumber = Input.PhoneNumber;
            usuario.DataNascimento = Input.DataNascimento;
            usuario.NomeUsuario = Input.NomeUsuario;
            _unitOfWork.RPGUser.Alterar(usuario);
            _unitOfWork.Salvar();
        }
    }
}
