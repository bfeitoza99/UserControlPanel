export * from './user.service';
import { UserService } from './user.service';
export * from './userAdress.service';
import { UserAdressService } from './userAdress.service';
export * from './userGender.service';
import { UserGenderService } from './userGender.service';
export const APIS = [UserService, UserAdressService, UserGenderService];
