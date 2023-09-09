import BackendService from "./BackendService";

export class UtilService{
    public static async verifyReCaptchaToken(token: string, actionName: string):Promise<boolean>{
        if(token == ""){
            return false
        }
        let result = await BackendService.verifyRecaptchaToken(token, actionName);
        return result.data;
     }

    public static async getRecaptchaToken(executeRecaptcha:  (((action?: (string | undefined)) => Promise<string>) | undefined), actionName: string): Promise<string>{
        if (!executeRecaptcha) {
            console.log('Execute recaptcha not yet available');
            return "";
        }
        return await executeRecaptcha(actionName);
    }
}
