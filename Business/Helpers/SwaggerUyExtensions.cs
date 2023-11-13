using Swashbuckle.AspNetCore.SwaggerUI;

public static class SwaggerUIExtensions
{
    public static void InjectJwtScript(this SwaggerUIOptions swaggerUIOptions)
    {
        swaggerUIOptions.HeadContent = @"
        <script>
            function addJwt() {
                var token = prompt('Enter your JWT token');
                if (token) {
                    window.localStorage.setItem('swagger_access_token', token);
                    alert('Token added successfully!');
                }
            }
        </script>
        <style>
            .authorize-btn {
                display: none !important;
            }
        </style>";
    }
}
