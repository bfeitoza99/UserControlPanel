import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {FormBuilder, FormControl, FormGroup, Validators, ValidatorFn,AbstractControl,ValidationErrors} from '@angular/forms';
import { UserAddressFacadeService } from '../services/facade/user-adress.service';
import { UserGenderFacadeService } from '../services/facade/user-gender.service';
import { UserFacadeService } from '../services/facade/user.service';
import { UserAdressQueryResponse } from '../services/swagger-generated';
import { UserGenderQueryResponse, UserGenderReponse } from '../services/swagger-generated/model/userGenderQueryResponse';
import { SpinnerService } from '../services/spinner.service';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

public userForm: FormGroup;
public isSubmited: boolean = false;
public genders: UserGenderReponse[] = [];
public address: UserAdressQueryResponse;


constructor(private fb: FormBuilder,
  private toastr: ToastrService,
  private userAddressService:UserAddressFacadeService,  
    private userGenderService:UserGenderFacadeService,
    private userService:UserFacadeService,
    public spinnerService: SpinnerService) { 

}

  async ngOnInit() {
    this.createForm();
    this.disableAdressFields();
    this.genders = await (await this.userGenderService.getGenderAsync()).userGenders;  
    
  }

  private createForm() {
    this.userForm = this.fb.group({
      name: new FormControl("", [
        Validators.required
      ]),
      cpf: new FormControl("", [
        Validators.required,
        Validators.minLength(11)
      ]),
      email: new FormControl("", [
        Validators.required
      ]),
      number: new FormControl("", [
        Validators.required
      ]),
      birthDate: new FormControl("", [
        Validators.required
      ]),
      gender: new FormControl("default", [
        Validators.required,
        this.genderEqualsDefault()
      ]),
      cep: new FormControl("", [
        Validators.required,
        Validators.minLength(8)
      ]),
      city: new FormControl("", []),
      street: new FormControl("", []),
      neighbourhood: new FormControl("", []),
    });
  }

  disableAdressFields(){
    this.userForm.get('neighbourhood')?.disable();
    this.userForm.get('street')?.disable();
    this.userForm.get('city')?.disable();
  }
  
  disableAllFields(){
    this.userForm.get('name')?.disable();
    this.userForm.get('cpf')?.disable();
    this.userForm.get('email')?.disable();
    this.userForm.get('number')?.disable();
    this.userForm.get('birthDate')?.disable();
    this.userForm.get('gender')?.disable();
    this.userForm.get('cep')?.disable();
    
    this.disableAdressFields();
  } 

  enableAllField(){
    this.userForm.get('name')?.enable();
    this.userForm.get('cpf')?.enable();
    this.userForm.get('email')?.enable();
    this.userForm.get('number')?.enable();
    this.userForm.get('birthDate')?.enable();
    this.userForm.get('gender')?.enable();
    this.userForm.get('cep')?.enable();
    this.userForm.get('neighbourhood')?.enable();
    this.userForm.get('street')?.enable();
    this.userForm.get('city')?.enable();
  }

  validateFieldsIsValid(){
    const cpf = this.userForm.get('cpf')   
    if(cpf?.value != "" && cpf?.valid){
      if(!this.validateCPF(cpf.value))
         this.errorToast("CPF");
    }

    const email = this.userForm.get('email')?.value
    if(email != ""){
      let regex = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
      if(!regex.test(email))
          this.errorToast("Email");
    }
  }

  validateCPF(value: any) {
    var sum = 0;
    var resto;
    var inputCPF = value;

    if(inputCPF == '00000000000') return false;
    for(let i=1; i<=9; i++) sum = sum + parseInt(inputCPF.substring(i-1, i)) * (11 - i);
    resto = (sum * 10) % 11;

    if((resto == 10) || (resto == 11)) resto = 0;
    if(resto != parseInt(inputCPF.substring(9, 10))) return false;

    sum = 0;
    for(let i = 1; i <= 10; i++) sum = sum + parseInt(inputCPF.substring(i-1, i))*(12-i);
    resto = (sum * 10) % 11;

    if((resto == 10) || (resto == 11)) resto = 0;
    if(resto != parseInt(inputCPF.substring(10, 11))) return false;
    return true;
  }
   
   genderEqualsDefault(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const forbidden = control.value == "default"
      return forbidden ? {defaultValue: {value: control.value}} : null;
    };
  }


  errorToast(field: string){
    this.toastr.error(`Campo ${field} Inválido`);
  }

  submit(){
    this.validateFieldsIsValid();
    this.isSubmited = true;
  }

  async validateCep(){
    let cep = this.userForm.controls['cep'];      
    if(cep.valid){
      this.address = await this.userAddressService.getAddressAsync(cep.value);
        if(this.address.cep == null){
          this.fillEmptyAddress();
          this.errorToast("CEP");
          return;
        }
      this.fillAddress();
    }
  }

  fillAddress() {
    this.userForm.controls['city'].setValue(this.address.city)
    this.userForm.controls['street'].setValue(this.address.street)
    this.userForm.controls['neighbourhood'].setValue(this.address.neighbourhood)
  }

  fillEmptyAddress() {
    this.userForm.controls['city'].setValue("")
    this.userForm.controls['street'].setValue("")
    this.userForm.controls['neighbourhood'].setValue("")
  }

  

}


