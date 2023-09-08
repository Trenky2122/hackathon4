import axios, {AxiosResponse} from "axios";
import { RegistrationResultEnum } from "../Models/Models";

class SongbookBackendService{
    static config = require("../config.json");
    static serverUrl = SongbookBackendService.config.serverUrl;

    // region Registration

    static VerifyLink(link: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.get<RegistrationResultEnum>(this.serverUrl+"");
    }

    static CreateRegistrationLink(email: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.post<RegistrationResultEnum>(this.serverUrl+"");
    }

    static Register(user: string): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.post<RegistrationResultEnum>(this.serverUrl+"");
    }

    // endregion

}
export default  SongbookBackendService;
