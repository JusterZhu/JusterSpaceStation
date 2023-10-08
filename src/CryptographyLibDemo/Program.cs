namespace CryptographyLibDemo
{
    using System;
    using System.Security.Cryptography;
    using System.Security.Principal;

    class Program
    {
        static void Main(string[] args)
        {
            // 模拟用户注册，将用户名和密码进行加密存储
            string username = "user123";
            string password = "userPassword123";
            string hashedPassword = HashPassword(password);

            // 模拟用户登录，进行身份验证和授权
            if (AuthenticateUser(username, hashedPassword))
            {
                Console.WriteLine($"User {username} authenticated successfully!");

                // 设置用户身份信息
                GenericIdentity identity = new GenericIdentity(username);
                string[] roles = GetRoles(username);
                GenericPrincipal principal = new GenericPrincipal(identity, roles);

                // 在Thread.CurrentPrincipal中设置身份验证和授权信息
                System.Threading.Thread.CurrentPrincipal = principal;

                // 在这里添加授权逻辑
                if (IsUserAuthorized("Admin"))
                {
                    Console.WriteLine("User has Admin privileges.");
                }
                else
                {
                    Console.WriteLine("User does not have Admin privileges.");
                }
            }
            else
            {
                Console.WriteLine($"User {username} authentication failed.");
            }

            Console.ReadLine();
        }

        // 使用CryptographyLib进行密码加密
        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // 用户身份验证
        static bool AuthenticateUser(string username, string inputPassword)
        {
            // 在实际应用中，通常会查询数据库或其他存储，验证用户名和加密后的密码是否匹配
            // 这里简单比较输入的密码和预先加密存储的密码
            string storedPassword = "userPassword123"; // 这里是模拟的已加密密码
            return inputPassword.Equals(storedPassword, StringComparison.OrdinalIgnoreCase);
        }

        // 获取用户角色信息（模拟）
        static string[] GetRoles(string username)
        {
            // 在实际应用中，通常会查询数据库或其他存储，获取用户的角色信息
            // 这里简单返回一个固定的角色数组（模拟）
            return new string[] { "Admin", "User" };
        }

        // 检查用户是否有特定权限
        static bool IsUserAuthorized(string role)
        {
            // 在实际应用中，根据用户的角色信息来确定是否有特定权限
            // 这里简单比较用户的角色是否包含特定角色（模拟）
            IPrincipal principal = System.Threading.Thread.CurrentPrincipal;
            return principal.IsInRole(role);
        }
    }
}
