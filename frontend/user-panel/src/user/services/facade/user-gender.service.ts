import { Injectable } from "@angular/core";
import { UserAdressQueryResponse,  UserGenderService } from "../swagger-generated";
import { UserGenderQueryResponse } from "../swagger-generated/model/userGenderQueryResponse";

@Injectable({
    providedIn: 'root'
})
export class UserGenderFacadeService {
    constructor(private userGenderService: UserGenderService){}


    public  getGenderAsync(): Promise<UserGenderQueryResponse>{
        return new Promise((resolve, reject) => {
    
            const successCallback = async (data: UserGenderQueryResponse) => {
              resolve(data);
            };
            const errorCallback = error => reject(error);
      
            this.userGenderService.apiUserGenderGetAllGet()
            .subscribe(successCallback, errorCallback);
          });
        }
}