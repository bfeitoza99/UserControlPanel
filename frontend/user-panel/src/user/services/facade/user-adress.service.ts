import { Injectable } from "@angular/core";
import { UserAdressQueryResponse, UserAdressService } from "../swagger-generated";

@Injectable({
    providedIn: 'root'
})
export class UserAddressFacadeService {
    constructor(private userAddressService: UserAdressService){}


    public  getAddressAsync(cep:string): Promise<UserAdressQueryResponse>{
        return new Promise((resolve, reject) => {
    
            const successCallback = async (data: UserAdressQueryResponse) => {
              resolve(data);
            };
            const errorCallback = error => reject(error);
      
            this.userAddressService.apiUserAdressCepGet(cep)
            .subscribe(successCallback, errorCallback);
          });
        }
}