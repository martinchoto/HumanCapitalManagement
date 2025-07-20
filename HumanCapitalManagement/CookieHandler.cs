namespace HumanCapitalManagement
{
	public class CookieHandler : DelegatingHandler
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public CookieHandler(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var httpContext = _httpContextAccessor.HttpContext;
			if (httpContext?.Request.Headers.ContainsKey("Cookie") == true)
			{
				request.Headers.Add("Cookie", httpContext.Request.Headers["Cookie"].ToString());
			}
			return base.SendAsync(request, cancellationToken);
		}
	}
}
