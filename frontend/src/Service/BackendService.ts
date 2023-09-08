import axios, {AxiosResponse} from "axios";
import { RegistrationResultEnum } from "../Models/Models";

class SongbookBackendService{
    static config = require("../config.json");
    static serverUrl = SongbookBackendService.config.serverUrl;

    static CreateRegistrationLink(): Promise<AxiosResponse<RegistrationResultEnum>>{
        return axios.get<RegistrationResultEnum>(this.serverUrl+"Author/allForAnalysis");
    }
}
export default  SongbookBackendService;
