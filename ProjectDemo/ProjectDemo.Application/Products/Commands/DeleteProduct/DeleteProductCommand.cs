using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public string Id { get; set; }
    }
}
