using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RjwShop.Core.Models;
using RjwShop.DataAccess.InMemory;

namespace RjwShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategory
        InMemoryRepository<ProductCategory> context;

        public ProductCategoryManagerController() {
            context = new InMemoryRepository<ProductCategory>();
        }

        public ActionResult Index() {
            List<ProductCategory> productCategory = context.Collection().ToList();
            return View(productCategory);
        }

        public ActionResult Create() {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory) {
            if (!ModelState.IsValid) {
                return View(productCategory);
            } else {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id) {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null) {
                return HttpNotFound();
            } else {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id) {
            ProductCategory productToEdit = context.Find(Id);
            if (productToEdit == null) {
                return HttpNotFound();
            } else {
                if (!ModelState.IsValid) {
                    return View(productCategory);
                }

                productToEdit.Category = productCategory.Category;
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id) {
            ProductCategory productToDelete = context.Find(Id);
            if (productToDelete == null) {
                return HttpNotFound();
            } else {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id) {
            ProductCategory productToDelete = context.Find(Id);
            if (productToDelete == null) {
                return HttpNotFound();
            } else {
                if (!ModelState.IsValid) {
                    return View(productToDelete);
                } else {
                    context.Delete(Id);
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}