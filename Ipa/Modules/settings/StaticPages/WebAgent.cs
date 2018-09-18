using System;
using RestSharp.Portable;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using Plugin.Connectivity;
using RestSharp.Portable.HttpClient;

namespace Ipa
{
//	public enum StaticPageType{ AboutUs, TermsAndCondition, PrivacyPolicy }
//	
//	public class WebAgent
//	{
//		public async Task<string> GetWebContent(StaticPageType type, Action<Meta> ErrorCallback = null){
//
//			if (CrossConnectivity.Current.IsConnected) {
//				using (RestClient Client = new RestClient (AppConstants.BASE_URL)) {
//					Client.IgnoreResponseStatusCode = true;
//					bool IsLoopBack = false;
//					Restart:
//					RestRequest Request = new RestRequest ("/common/get-page-info/{page}", HttpMethod.Get);
//					Request.AddParameter ("authorization", App.UserInfo.AuthToken, ParameterType.HttpHeader);
//
//					if (StaticPageType.AboutUs == type) {
//						Request.AddUrlSegment ("page", "ABOUT");
//					} else if (StaticPageType.TermsAndCondition == type) {
//						Request.AddUrlSegment ("page", "TERMS-AND-CONDITIONS");
//					} else {
//						Request.AddUrlSegment ("page", "PRIVACY-POLICY");
//					}
//				
//
//					IRestResponse<StaticPageResponse> Response = await Client.Execute<StaticPageResponse> (Request);
//					Debug.WriteLine (System.Text.Encoding.UTF8.GetString (Response.RawBytes, 0, Response.RawBytes.Length));
//					if (Response.IsSuccess) {
//						return Response.Data.PageInfo.Content;
//					} else {
//						if (Response.Data.Meta.StatusCode == 401 && !IsLoopBack) {
//							App.UserInfo.AuthToken = await App.UserInfo.GetAuthToken ();
//							IsLoopBack = true;
//							goto Restart;
//						}
//						if (ErrorCallback != null) {
//							ErrorCallback.Invoke (Response.Data.Meta); // Or create a Meta object with error code and message
//						}
//						return null;
//					}
//
//				}
//			} else {
//				return null;
//			}
//		}
//	}
//
//
//	public class PageInfo
//	{
//		[JsonProperty(PropertyName = "pageName", NullValueHandling = NullValueHandling.Ignore)]
//		public string PageName { get; set; }
//		[JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
//		public string Content { get; set; }
//	}
//
//	public class StaticPageResponse
//	{
//		[JsonProperty(PropertyName = "meta", NullValueHandling = NullValueHandling.Ignore)]
//		public Meta Meta { get; set; }
//		[JsonProperty(PropertyName = "pageInfo", NullValueHandling = NullValueHandling.Ignore)]
//		public PageInfo PageInfo { get; set; }
//	}
}

