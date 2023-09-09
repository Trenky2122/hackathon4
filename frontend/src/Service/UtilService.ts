import {RequestTypeEnum} from "../Models/Models";
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

    public static UserIsLogged(): boolean {
        return localStorage.getItem("loggedIn") == "true";
    }

    public static CalculateTaxAmountForRequest(caseIndex: number, isYearly: boolean): number {
        if(isYearly) {
            switch (caseIndex) {
                case RequestTypeEnum.ParkingPermit:
                    return 365;
                case RequestTypeEnum.Sightseeing:
                    return 6000;
                case RequestTypeEnum.PoliceException:
                    return 3900;
                case RequestTypeEnum.Supplying:
                    return 1400;
                case RequestTypeEnum.ShipSupplying:
                    return 2000;
                case RequestTypeEnum.SupplyingGreen:
                    return 200;
                case RequestTypeEnum.CleaningSecurity:
                    return 702;
                case RequestTypeEnum.Resident:
                case RequestTypeEnum.HandicappedResidentWorker:
                    return 10;
                default:
                    return 0;
            }
        }
        switch (caseIndex) {
            case RequestTypeEnum.Resident:
            case RequestTypeEnum.HandicappedResidentWorker:
                return 0.1;
            case RequestTypeEnum.ParkingPermit:
            case RequestTypeEnum.SupplyingGreen:
                return 1;
            case RequestTypeEnum.CleaningSecurity:
                return 3;
            case RequestTypeEnum.Supplying:
            case RequestTypeEnum.Maintenance:
                return 5;
            case RequestTypeEnum.ShipSupplying:
                return 9;
            case RequestTypeEnum.SpecialUseOfCommunications:
            case RequestTypeEnum.PoliceException:
                return 15;
            case RequestTypeEnum.Wedding:
            case RequestTypeEnum.Sightseeing:
                return 30;
            default:
                return 0;
        }
    }
}
