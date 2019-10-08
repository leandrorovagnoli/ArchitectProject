using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Service;
using ArchitectProject.UI.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ArchitectProject.UI.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdminController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IMenuService _menuService;
        private readonly IGalleryItemService _galleryItemService;
        private AdminViewModel _adminViewModel;

        public AdminController(SignInManager<IdentityUser> signInManager, ILogger<AdminController> logger,
            ICustomerService customerService, IMenuService menuService, IGalleryItemService galleryItemService,
            AdminViewModel adminViewModel)
        {
            _signInManager = signInManager;
            _logger = logger;
            _customerService = customerService;
            _menuService = menuService;
            _galleryItemService = galleryItemService;
            _adminViewModel = adminViewModel;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return View();
            }
        }

        #region Customer

        /// <summary>
        /// Call the Customer main page with all customers listed. 
        /// </summary>
        /// <returns></returns>
        [Route("Gerenciar/Cliente")]
        public ActionResult Customer()
        {
            UpdateCustomers(_adminViewModel);

            return View("Customer", _adminViewModel);
        }

        /// <summary>
        /// Gets all customers from DB and updates its viewmodel.
        /// </summary>
        /// <returns>Return all Customers from DB</returns>
        [Route("Gerenciar/Cliente/ObterClientes")]
        public ICollection<Customer> UpdateCustomers(AdminViewModel adminViewModel)
        {
            return adminViewModel.Customers = _customerService.GetAll().ToList();
        }

        /// <summary>
        /// Save a customer (HttpPost) from view.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [Route("Gerenciar/Cliente/SalvarCliente")]
        [HttpPost]
        public ActionResult SaveOrUpdateCustomer([Bind("Name,Surname,Email,Phone,Id")] Customer customer)
        {
            try
            {
                if (customer != null && customer.Id == 0)
                {
                    _customerService.Add(customer);
                    Alert("Cliente adicionado com sucesso!", Enum.NotificationType.success);
                }
                else
                {
                    _customerService.Update(customer);
                    Alert("Cliente atualizado com sucesso!", Enum.NotificationType.success);
                }
            }
            catch (Exception)
            {
                Alert("Informe ao administrador do sistema.", Enum.NotificationType.error);
            }

            ModelState.Clear();
            UpdateCustomers(_adminViewModel);

            return View("Customer", _adminViewModel);
        }

        /// <summary>
        /// Delete a customer from grid.
        /// </summary>
        /// <param name="id">Customer Id to be deleted.</param>
        /// <returns></returns>
        [Route("Gerenciar/Cliente/ApagarCliente")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetById(id);
                _customerService.Delete(customer);

                Alert("Cliente removido com sucesso!", Enum.NotificationType.success);
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            ModelState.Clear();
            UpdateCustomers(_adminViewModel);

            return View("Customer", _adminViewModel);
        }

        /// <summary>
        /// Edit a customer from grid.
        /// </summary>
        /// <param name="id">Customer Id to be edited.</param>
        /// <returns></returns>
        [Route("Gerenciar/Cliente/EditarCliente")]
        public ActionResult EditCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetById(id);
                _adminViewModel.Customer = customer;
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            UpdateCustomers(_adminViewModel);

            return View("Customer", _adminViewModel);
        }

        #endregion

        #region Menu

        /// <summary>
        /// Call the Menu main page with all menus listed. 
        /// </summary>
        /// <returns></returns>
        [Route("Gerenciar/Menu")]
        public ActionResult Menu()
        {
            UpdateMenus(_adminViewModel);

            return View("Menu", _adminViewModel);
        }

        /// <summary>
        /// Gets all Menus from DB and updates its viewmodel.
        /// </summary>
        /// <returns>Return all Menus from DB</returns>
        [Route("Gerenciar/Menu/ObterMenus")]
        public IEnumerable<Menu> UpdateMenus(AdminViewModel adminViewModel)
        {
            adminViewModel.MenuList = _menuService.GetAll().ToList();
            adminViewModel.MenuDropDownList = adminViewModel.MenuList.ToList();

            return adminViewModel.MenuList;
        }

        /// <summary>
        /// Save a menu (HttpPost) from view.
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Route("Gerenciar/Menu/SalvarMenu")]
        [HttpPost]
        public ActionResult SaveOrUpdateMenu([Bind("Name,SubMenu,Id,MenuId")] Menu menu)
        {
            try
            {
                if (menu != null && menu.Id == 0)
                {
                    _menuService.Add(menu);
                    Alert("Menu adicionado com sucesso!", Enum.NotificationType.success);
                }
                else
                {
                    if (menu.Id != menu.MenuId)
                    {
                        _menuService.Update(menu);
                        Alert("Menu atualizado com sucesso!", Enum.NotificationType.success);
                    }
                    else
                        Alert("Informe ao administrador do sistema.", Enum.NotificationType.error);
                }
            }
            catch (Exception)
            {
                Alert("Informe ao administrador do sistema.", Enum.NotificationType.error);
            }

            ModelState.Clear();
            UpdateMenus(_adminViewModel);

            return View("Menu", _adminViewModel);
        }

        /// <summary>
        /// Delete a menu from grid.
        /// </summary>
        /// <param name="id">Menu Id to be deleted.</param>
        /// <returns></returns>
        [Route("Gerenciar/Menu/ApagarMenu")]
        public ActionResult DeleteMenu(int id)
        {
            try
            {
                var menu = _menuService.GetById(id);
                _menuService.Delete(menu);

                Alert("Menu removido com sucesso!", Enum.NotificationType.success);
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            ModelState.Clear();
            UpdateMenus(_adminViewModel);

            return View("Menu", _adminViewModel);
        }

        /// <summary>
        /// Edit a menu from grid.
        /// </summary>
        /// <param name="id">Menu Id to be edited.</param>
        /// <returns></returns>
        [Route("Gerenciar/Menu/EditarMenu")]
        public ActionResult EditMenu(int id)
        {
            try
            {
                var menu = _menuService.GetById(id);
                _adminViewModel.Menu = menu;
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            _adminViewModel.IsEditMode = true;

            UpdateMenus(_adminViewModel);

            return View("Menu", _adminViewModel);
        }

        #endregion

        #region Gallery

        /// <summary>
        /// Call the Gallery main page with all galleries listed. 
        /// </summary>
        /// <returns></returns>
        [Route("Gerenciar/Galeria")]
        public ActionResult Gallery()
        {
            ClearGalleryState();
            UpdateGalleries(_adminViewModel);

            return View("Gallery", _adminViewModel);
        }

        /// <summary>
        /// Clear the current state of the Gallery.
        /// </summary>
        [Route("Gerenciar/Galeria/LiberarEstado")]
        public void ClearGalleryState()
        {
            ModelState.Clear();
            _adminViewModel.GalleryItem = new GalleryItem() { IsActive = true };
        }

        /// <summary>
        /// Gets all Galleries from DB and updates its viewmodel.
        /// </summary>
        /// <returns>Return all Galleries from DB</returns>
        [Route("Gerenciar/Galeria/ObterGalerias")]
        public IEnumerable<GalleryItem> UpdateGalleries(AdminViewModel adminViewModel)
        {
            adminViewModel.GalleryList = _galleryItemService.GetAll().ToList();
            adminViewModel.MenuDropDownList = _menuService.GetAll().ToList();
            adminViewModel.MenuList = adminViewModel.MenuDropDownList.ToList();

            return adminViewModel.GalleryList;
        }

        /// <summary>
        /// Save a Gallery (HttpPost) from view.
        /// </summary>
        /// <param name="galleryItem"></param>
        /// <returns></returns>
        [Route("Gerenciar/Galeria/SalvarGaleria")]
        [HttpPost]
        public ActionResult SaveOrUpdateGallery([Bind("Id,Title,Description,PublishDate,IsActive,MenuId")] GalleryItem galleryItem)
        {
            try
            {
                if (galleryItem != null && galleryItem.Id == 0)
                {
                    galleryItem.PublishDate = DateTime.Now;
                    _galleryItemService.Add(galleryItem);
                    Alert("Galeria adicionada com sucesso!", Enum.NotificationType.success);
                }
                else
                {
                    _galleryItemService.Update(galleryItem);
                    Alert("Galeria atualizada com sucesso!", Enum.NotificationType.success);
                }
            }
            catch (Exception)
            {
                Alert("Informe ao administrador do sistema.", Enum.NotificationType.error);
            }

            ClearGalleryState();
            UpdateGalleries(_adminViewModel);

            return View("Gallery", _adminViewModel);
        }

        /// <summary>
        /// Delete a gallery from grid.
        /// </summary>
        /// <param name="id">Gallery Id to be deleted.</param>
        /// <returns></returns>
        [Route("Gerenciar/Galeria/ApagarGaleria")]
        public ActionResult DeleteGallery(int id)
        {
            try
            {
                var gallery = _galleryItemService.GetById(id);
                _galleryItemService.Delete(gallery);

                Alert("Galeria removida com sucesso!", Enum.NotificationType.success);
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            ClearGalleryState();
            UpdateGalleries(_adminViewModel);

            return View("Gallery", _adminViewModel);
        }

        /// <summary>
        /// Edit a gallery from grid.
        /// </summary>
        /// <param name="id">Gallery Id to be edited.</param>
        /// <returns></returns>
        [Route("Gerenciar/Galeria/EditarGaleria")]
        public ActionResult EditGallery(int id)
        {
            try
            {
                var gallery = _galleryItemService.GetById(id);
                _adminViewModel.GalleryItem = gallery;
            }
            catch (Exception)
            {
                Alert("Ocorreu um erro! Informe o administrador do sistema.", Enum.NotificationType.error);
            }

            UpdateGalleries(_adminViewModel);

            return View("Gallery", _adminViewModel);
        }

        #endregion
    }
}