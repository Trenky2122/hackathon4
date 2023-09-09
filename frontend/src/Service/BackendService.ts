import axios, {AxiosResponse} from "axios";
import { RegistrationResultEnum } from "../Models/Models";

class SongbookBackendService{
    static config = require("../config.json");
    static serverUrl = SongbookBackendService.config.serverUrl;

    // region Registration

    static verifyLink(link: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.get<RegistrationResultEnum>(this.serverUrl+"");
    }

    static createRegistrationLink(email: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.post<RegistrationResultEnum>(this.serverUrl+"");
    }

    static register(user: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.post<RegistrationResultEnum>(this.serverUrl+"");
    }

    // endregion

    //region User

    static verifyRecaptchaToken(token: string, action: string): Promise<AxiosResponse<boolean>>{
        return axios.post(this.serverUrl+"recaptcha/"+token+"/"+action);
    }

    //endregion

}
export default  SongbookBackendService;
