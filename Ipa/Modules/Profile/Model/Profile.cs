using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class Profile
	{
//		{"responseCode":"1000","apiResponse":{"profileInfo":,"organizationInfo":}
		[JsonProperty(PropertyName ="profileInfo", NullValueHandling = NullValueHandling.Ignore)]
		public ProfileDetail PersonalInfo = new ProfileDetail();
		[JsonProperty(PropertyName ="organizationInfo", NullValueHandling = NullValueHandling.Ignore)]
		public OrganizationDetail OrganizationInfo = new OrganizationDetail();

	}

	public class ProfileDetail{
//		{"userName":"","fullName":"","surName":"","profileImage":"<URL>", "phone":"", "emailID":"", "roleID":1}
		[JsonProperty(PropertyName ="userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName{ get; set;}
		[JsonProperty(PropertyName ="password", NullValueHandling = NullValueHandling.Ignore)]
		public string Password{ get; set;}
		[JsonProperty(PropertyName ="fullName", NullValueHandling = NullValueHandling.Ignore)]
		public string FullName{ get; set;}
		[JsonProperty(PropertyName ="surName", NullValueHandling = NullValueHandling.Ignore)]
		public string SurName{ get; set;}
		[JsonProperty(PropertyName ="profileImage", NullValueHandling = NullValueHandling.Ignore)]
		public string ProfileImage{ get; set;}
		[JsonProperty(PropertyName ="phone", NullValueHandling = NullValueHandling.Ignore)]
		public string Phone{ get; set;}
		[JsonProperty(PropertyName ="emailID", NullValueHandling = NullValueHandling.Ignore)]
		public string EmailId{ get; set;}
	}

	public class OrganizationDetail{
//		{"organizationName":"", "empId":"","designation":"","city":""}
		[JsonProperty(PropertyName ="organizationName", NullValueHandling = NullValueHandling.Ignore)]
		public string OrganizationName{ get; set;}
		[JsonProperty(PropertyName ="empId", NullValueHandling = NullValueHandling.Ignore)]
		public string EmpId{ get; set;}
		[JsonProperty(PropertyName ="designation", NullValueHandling = NullValueHandling.Ignore)]
		public string Designation{ get; set;}
		[JsonProperty(PropertyName ="city", NullValueHandling = NullValueHandling.Ignore)]
		public string City{ get; set;}
	}

}
