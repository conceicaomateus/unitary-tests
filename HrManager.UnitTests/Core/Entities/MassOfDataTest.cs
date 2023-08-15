using HrManager.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace HrManager.UnitTests.Core.Entities;

public class MassOfDataTest
{
    #region MemberData

    public static IEnumerable<object[]> UserList => new[]
{
        new [] { new User { Id = 1, Username = "admin", Email = "admin@example.com" } },
        new [] { new User { Id = 2, Username = "user1", Email = "user1@example.com" } },
        new [] { new User { Id = 3, Username = "user2", Email = "user2@example.com" } },
        new [] { new User { Id = 4, Username = "user3", Email = "user3@example.com" } },
    };

    [Theory]
    [MemberData(nameof(UserList))]
    public void Check_UserFieldsHasContent_Sucess(User user)
    {
        Assert.NotNull(user.Username);
        Assert.NotEmpty(user.Username);
        Assert.NotNull(user.Email);
        Assert.NotEmpty(user.Email);
        Assert.IsType<User>(user);
    }

    #endregion

    #region ClassData

    public class UserListData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new [] { new User { Id = 1, Username = "admin", Email = "admin@example.com" } },
            new [] { new User { Id = 2, Username = "user1", Email = "user1@example.com" } },
            new [] { new User { Id = 3, Username = "user2", Email = "user2@example.com" } },
            new [] { new User { Id = 4, Username = "user3", Email = "user3@example.com" } },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(UserListData))]
    public void Check_UserFieldsHasContentClass_Sucess(User user)
    {
        Assert.NotNull(user.Username);
        Assert.NotEmpty(user.Username);
        Assert.NotNull(user.Email);
        Assert.NotEmpty(user.Email);
        Assert.IsType<User>(user);
    }

    #endregion
}
