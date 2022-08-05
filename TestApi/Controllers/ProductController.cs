﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Contracts;
using Onion.Application.Contracts.ProductApplication_Agg;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public ResultStatus _ResultStatus = new ResultStatus();

        private readonly IProductAppication _IProductApplication;
        private readonly IProductCategoryApplication _IProductCategoryApplication;


        public ProductController(IProductAppication productAppication)
        {
            _IProductApplication = productAppication;
        }

        [HttpGet]
        public List<ProductViewModel> GetProducts()
        {
            return _IProductApplication.GetAll();
        }


        [HttpPost("CreateProduct")]
        public ResultStatus PostCreateProduct(CreateProductCommand Command)
        {
            string Error = "";
            if (ModelState.IsValid)
            {
                _ResultStatus.IsOk = _IProductApplication.Create(Command, out Error);
                _ResultStatus.Error = Error;
            }
            else
            {
                _ResultStatus.Error = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0).ToString();
                _ResultStatus.IsOk = false;


            }
            return _ResultStatus;
        }

        [HttpPost("EditProdcut")]
        public ResultStatus PostEditProdcut(EditProductCommand Command)
        {

            _ResultStatus.IsOk = _IProductApplication.Edit(Command, out string Error);
            _ResultStatus.Error = Error;
            return _ResultStatus;
        }


        [HttpGet("DeActivate/{id}")]
        public ResultStatus GetDeActivate(int id)
        {
            string Error = "";
            _ResultStatus.IsOk = _IProductApplication.DeActivate(id, out Error);
            _ResultStatus.Error = Error;

            return _ResultStatus;

        }
        [HttpGet("Activate/{id}")]
        public ResultStatus GetActivate(int id)
        {
            string Error = "";
            _ResultStatus.IsOk = _IProductApplication.Activate(id, out Error);
            _ResultStatus.Error = Error;

            return _ResultStatus;

        }

    }
}
