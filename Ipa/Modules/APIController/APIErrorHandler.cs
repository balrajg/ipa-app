using System;
using System.Diagnostics;

namespace Ipa
{
	public static class WebServiceErrorHandler
	{
//		public async static void Handle(Meta _MetaData){
//			
//			System.Diagnostics.Debug.WriteLine ("API Error ::>> Code "+_MetaData.StatusCode+",\n Message"+_MetaData.Message);
//			string AlertMessage = string.Empty;
//			if (null == _MetaData)
//				return;
//			
//			switch (_MetaData.StatusCode) {
//				
//			case 400://Bad Request
//			case 401://Bad Token
//			case 402:
//				{
//					//Authendication failed
//					AlertMessage = AppConstants.BAD_REQUEST;
//					break;
//				}
//			case 403:
//				{
//					//Failed while sending email
//					AlertMessage = AppConstants.CANT_SEND_VERIFICATION_EMAIL;
//					break;
//				}
//			case 404:
//			case 413:
//				{
//					//Account blocked
//					AlertMessage = AppConstants.BLOCK_ACCOUNT;
//					break;
//				}
//			case 405://Verification URL has been expired
//			case 406:
//				{
//					//Verification URL has been expired
//					//Not applicable for mobile app
//					return;
//					break;
//				}
//			case 407:
//				{
//					//Account not verified
//					AlertMessage = AppConstants.NOT_VERIFIED_USER;
//					break;
//				}
//			case 410:
//				{
//					//Email does not exist
//					AlertMessage = AppConstants.EMAIL_DOESNT_MATCH;
//					break;
//				}
//			case 412:
//				{
//					//user not exists     /* Should show register screen */
//					AlertMessage = AppConstants.USER_NOT_EXIST;
//					break;
//				}
//			case 415:
//				{
//					//Unsupported Media type
//					AlertMessage = AppConstants.UNSUPPORTED_MEDIA_TYPE;
//					break;
//				}
//			case 500:
//				{
//					//Internal server error
//					AlertMessage = AppConstants.SERVER_ERROR;
//					break;
//				}
//			case 601:
//				{
//					//Page not exist (For static pages)
//					AlertMessage = AppConstants.PAGE_NOR_EXIST;
//					break;
//				}
//			case 602:
//				{
//					//Inactive golf info
//					AlertMessage = AppConstants.INACTIVE_GOLF;
//					break;
//				}
//			case 603:
//				{
//					//Invalid Golf club id
//					AlertMessage = AppConstants.INVALID_GOLFID;
//					break;
//				}
//			case 701:
//				{
//					// Size/Limit exeed( upload file size)
//					AlertMessage = AppConstants.SIZE_EXEED;
//					break;
//				}
//			case 801:
//				{
//					//Permission denied for this role
//					AlertMessage = AppConstants.PERMISSION_DENIED;
//					break;
//				}
//			default :
//				{
//					Debug.WriteLine (string.Format (" Error code doesn't match with all code. \n Error code: {0}, Error message:{1}",_MetaData.StatusCode,_MetaData.Message));
//					break;
//				}
//
//			}
//
//			if (null != NavigationManager.CurrentNavigationPage) {
//				NavigationManager.CurrentNavigationPage.CurrentPage.DisplayAlert (AppConstants.APP_NAME, AlertMessage, AppConstants.OK_TEXT);
//			}
//		}
	}
}

