import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {FormBuilder, FormControl, FormGroup, Validators, ValidatorFn,AbstractControl,ValidationErrors} from '@angular/forms';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

public userForm: FormGroup;
public isSubmited: boolean = false;


constructor(private fb: FormBuilder,
  private toastr: ToastrService) { 

}

  ngOnInit(): void {
    this.createForm();
    this.disableAdressFields();
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
      gender: new FormControl("", [
        Validators.required
      ]),
      cep: new FormControl("", [
        Validators.required
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

  validateFieldsIsValid(){
    const cpf = this.userForm.get('cpf')   
    console.log(cpf?.value)
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
   


  errorToast(field: string){
    this.toastr.error(`Campo ${field} Inválido`);
  }

  submit(){
    this.validateFieldsIsValid();
    this.isSubmited = true;
  }
  

}


