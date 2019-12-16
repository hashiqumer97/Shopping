using AutoMapper;
using Shopping.BL.Interface;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using Shopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(ProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public List<ProductBL> GetProducts()
        {
            return mapper.Map<List<ProductBL>>(productRepository.GetProducts());
        }

        public ProductBL GetProductSubCategories(int id)
        {
            return mapper.Map<ProductBL>(unitOfWork.ProductRepository.GetByID(id));
        }

        public void Update(int productId, int quantity)
        {
            
            var productBO = unitOfWork.ProductRepository.GetByID(productId);
            productBO.Quantity = productBO.Quantity + quantity;
            var product = mapper.Map<ProductDL>(productBO);
            unitOfWork.ProductRepository.Update(product);
            unitOfWork.Save();

        }
    }
}
