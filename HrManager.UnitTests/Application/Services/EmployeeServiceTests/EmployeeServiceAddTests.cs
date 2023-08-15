using AutoFixture;
using HrManager.Application.Models.InputModels;
using HrManager.Application.Services;
using HrManager.Core.Entities;
using HrManager.Core.Exceptions;
using HrManager.Core.Repositories;
using Moq;
using System;
using Xunit;

namespace HrManager.UnitTests.Application.Services.EmployeeServiceTests;

public class EmployeeServiceAddTests
{
    [Fact]
    public void ValidEmployee_AddIsCalled_ReturnValidEmployeeViewModel()
    {
        #region Arrange

        var addEmploymentInputModel = new Fixture().Create<AddEmployeeInputModel>();
        addEmploymentInputModel.BirthDate = DateTime.Today.AddYears(-21);

        var employeeRepositoryMock = new Mock<IEmployeeRepository>();

        var employeeService = new EmployeeService(employeeRepositoryMock.Object);

        #endregion

        #region Act

        var result = employeeService.Add(addEmploymentInputModel);

        #endregion

        #region Assert

        Assert.Equal(addEmploymentInputModel.FullName, result.FullName);
        Assert.Equal(addEmploymentInputModel.Document, result.Document);
        Assert.Equal(addEmploymentInputModel.BirthDate, result.BirthDate);
        Assert.Equal(addEmploymentInputModel.RoleLevel, result.RoleLevel);
        Assert.Equal(addEmploymentInputModel.Role, result.Role);

        employeeRepositoryMock.Verify(er => er.Add(It.IsAny<Employee>()), Times.Once());

        #endregion
    }

    [Fact]
    public void InvalidBirthDateForEmployee_AddIsCalled_ThrowAnInvalidBirthDateException()
    {
        #region Arrange

        var addEmployeeInputModel = new Fixture().Create<AddEmployeeInputModel>();
        addEmployeeInputModel.BirthDate = DateTime.Today.AddDays(1);

        var employeeRepositoryMock = new Mock<IEmployeeRepository>();

        var employeeService = new EmployeeService(employeeRepositoryMock.Object);

        #endregion

        #region Act

        Action response = () => employeeService.Add(addEmployeeInputModel);

        #endregion

        #region Assert

        var exception = Assert.Throws<BirthDateCannotBeInTheFutureException>(response);

        Assert.Equal("Birth date cannot be in the future.", exception.Message);

        #endregion
    }
}

