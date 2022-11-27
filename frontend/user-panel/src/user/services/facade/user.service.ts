import { Injectable } from "@angular/core";
import { UserAdressQueryResponse,   UserCommandRequest,   UserCommandResponse,   UserService } from "../swagger-generated";

@Injectable({
    providedIn: 'root'
})
export class UserFacadeService {
    constructor(private userService: UserService){}


    public  createAsync(user: UserCommandRequest): Promise<UserCommandResponse> {
        return new Promise((resolve, reject) => {
          const successCallback = async (data: UserCommandResponse) => {
            resolve(data);
          };
          const errorCallback = error => {
            reject(error);
          };
    
          this.userService.apiUserPost(user)
            .subscribe(successCallback, errorCallback);
        });
      } 

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