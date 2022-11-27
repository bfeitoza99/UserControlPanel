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
import { BASE_PATH, UserAdressService, UserGenderService, UserService } from './services/swagger-generated';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CustomHttpInterceptor } from './services/http-interceptor.service';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

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
    HttpClientModule,
    MatProgressSpinnerModule 

  ],
  providers: [
    UserAdressService,
    UserGenderService,
    UserService,
    { provide: BASE_PATH, useValue: 'http://localhost:5002' },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomHttpInterceptor,
      multi: true
    }],
  bootstrap: [UserCreateComponent]
})
export class UserModule { }
