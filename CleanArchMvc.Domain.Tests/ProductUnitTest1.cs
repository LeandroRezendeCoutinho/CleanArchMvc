using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidstate()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", (decimal) 9.99, 99, "Product Image");
        action.Should().NotThrow<Validation.DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateProduct_WithInvalidId_ResultObjectValidstate()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", (decimal) 9.99, 99, "Product Image");
        action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid ID");
    }
    
    [Fact]
    public void CreateProduct_NullValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, null, "Product Description",
            (decimal) 9.99, 99, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name is required");
    }

    [Fact]
    public void CreateProduct_SmallProductName_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Pr", "Product Description",
            (decimal) 9.99, 99, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name must have at least 3 characters");
    }
    
    [Fact]
    public void CreateProduct_NullDescription_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", null,
            (decimal) 9.99, 99, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Description. Description is required");
    }
    
    [Fact]
    public void CreateProduct_SmallDescription_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", "Product",
            (decimal) 9.99, 99, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Description. Description must have at least 10 characters");
    }

    [Fact]
    public void CreateProduct_InvalidPrice_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", "Product Description",
            -1, 99, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Price");
    }

    [Fact]
    public void CreateProduct_InvalidStock_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", "Product Description",
            100, -1, "Product Image");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Stock");
    }
    
    [Fact]
    public void CreateProduct_ImageLength_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", "Product Description",
            100, 10, "Product Image length exceeds permitted size");
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, maximum of 25 characters");
    }
    
    [Fact]
    public void CreateProduct_WithNullImageName_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "Product", "Product Description",
            100, 10, null);
        action.Should().Throw < Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Image. Image is required");
    }
}