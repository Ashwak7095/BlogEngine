namespace Blog_MVC
{
    public static class URL
    {
        public const string WebApiUrl = "https://localhost:44345/";
        public const string GetBlog = "api/Blog/GetBlog";
        public const string CreateBlog = "api/Blog/AddBlog";
        public const string GetByIdBlog = "api/Blog/GetByIdBlog?id=";
        public const string UpdateBlog = "api/Blog/UpdateBlog";
        public const string DeleteBlog = "api/Blog/DeleteBlog?id=";
        public const string Login = "api/Authentication/login Model";
        public const string Register = "api/Authentication/register";
    }
}
