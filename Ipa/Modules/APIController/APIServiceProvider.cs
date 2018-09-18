using System;
using RestSharp.Portable;
using System.Diagnostics;
using RestSharp.Portable.HttpClient;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ipa
{
	public class APIServiceProvider
	{
		private APIServiceProvider ()
		{
		}

		private static APIServiceProvider _ServiceProvider;
		public static APIServiceProvider ServiceProvider{
			get{ 
				return _ServiceProvider ?? (_ServiceProvider = new APIServiceProvider());
			}
		}

		public const string BaseUrl = "http://www.ipaenablers.com";

		public readonly string AuthToken;

		public async Task<T> Execute<T>(RestRequest request) where T: new () {
			try {
				using(IRestClient client = new RestClient()){
					client.BaseUrl = new Uri(BaseUrl);
					client.IgnoreResponseStatusCode = true;
					
					IRestResponse<T> response = await client.Execute<T> (request);
                    string outputResponse = string.Format("ResponseData {0} RequestUrl {1}", JsonConvert.SerializeObject(response), request.Resource.ToString());
				    Debug.WriteLine("Success:D "+ outputResponse);
                    
                    return response.Data;
				}
			} catch (Exception ex) {
				Debug.WriteLine ("Error Occured on API hit :" + ex.Message);
				//Must call API error handler
				return default(T);
			}
		}

				public async Task<string> Execute(RestRequest request)  {
			try {
				using (IRestClient client = new RestClient ()) {
					client.BaseUrl = new Uri (BaseUrl);
					client.IgnoreResponseStatusCode = true;
					//Debug.WriteLine(JsonConvert.SerializeObject());
					IRestResponse response = await client.Execute (request);
										
					Debug.WriteLine (JsonConvert.SerializeObject (response));
					if (response.IsSuccess) {
						return "Success";
					} else {
						return null;
					}

				}
			} catch (Exception ex) {
				Debug.WriteLine ("Error Occured on API hit :" + ex.Message);
				//Must call API error handler
				return null;
			}
		}


	}
}

