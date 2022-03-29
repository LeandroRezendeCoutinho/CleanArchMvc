using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category with valid state")]
    public void CreateCategory_WithValidParams_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category with invalid id")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id");
    }
    
    [Fact(DisplayName = "Create Category with small name")]
    public void CreateCategory_SmallNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "Na");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name must have at least 3 characters");
    }
    
    [Fact(DisplayName = "Create Category without name")]
    public void CreateCategory_NullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name is required");
    }
}