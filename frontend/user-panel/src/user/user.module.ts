import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserCreateComponent } from './user-create/user-create.component';
import { BrowserModule } from '@angular/platform-browser';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule , IConfig } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    UserCreateComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    UserRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule ,ReactiveFormsModule,
    NgxMaskModule.forRoot(maskConfig),
    ToastrModule.forRoot(),

  ],
  providers: [],
  bootstrap: [UserCreateComponent]
})
export class UserModule { }
