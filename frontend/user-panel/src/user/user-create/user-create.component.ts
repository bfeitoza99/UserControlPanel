import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators, ValidatorFn,AbstractControl,ValidationErrors} from '@angular/forms';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

public userForm: FormGroup;
public isSubmited: boolean = false;


constructor(private fb: FormBuilder) { 

}

  ngOnInit(): void {
    this.userForm = this.fb.group({
      name: new FormControl("", [
        Validators.required
      ]),
      cpf: new FormControl("", [
        Validators.required,
        Validators.minLength(11),
        this.validateCpfFormat(new RegExp('([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?0-9]{2})'))
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
      city: new FormControl("", [        
      ]), 
      street: new FormControl("", [       
      ]), 
      neighbourhood: new FormControl("", [        
      ]), 
    });
  
    this.disableAdressFields();
  }

  disableAdressFields(){
    this.userForm.get('neighbourhood')?.disable();
    this.userForm.get('street')?.disable();
    this.userForm.get('city')?.disable();
  }

  validateCpfFormat(nameRe: RegExp): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const forbidden = nameRe.test(control.value);
      return forbidden ? {forbiddenName:'CpfInvalid' } : null;
    };
  }
   


  submit(){
    // console.log(this.userForm)

   
    console.log(this.userForm.get('birthDate')?.value)
    

    

    // if(cpf != null){
    //   let regex = new RegExp('([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?0-9]{2})');
    //   console.log(regex.test(cpf));
    // }

    this.isSubmited = true;
  }
  // get name() { return this.name.get('name'); }

}


