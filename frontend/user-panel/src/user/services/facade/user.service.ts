import { Injectable } from "@angular/core";
import { UserAdressQueryResponse,   UserService } from "../swagger-generated";

@Injectable({
    providedIn: 'root'
})
export class UserFacadeService {
    constructor(private userService: UserService){}


    // public  getGenderAsync(): Promise<UserAdressQueryResponse>{
    //     return new Promise((resolve, reject) => {
    
    //         const successCallback = async (data: UserAdressQueryResponse) => {
    //           resolve(data);
    //         };
    //         const errorCallback = error => reject(error);
      
    //         this.userGenderService.apiUserGenderGetAllGet()
    //         .subscribe(successCallback, errorCallback);
    //       });
    //     }
}