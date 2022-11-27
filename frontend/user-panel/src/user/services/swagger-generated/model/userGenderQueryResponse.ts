
export interface UserGenderQueryResponse{
userGenders: UserGenderReponse[];
}

export interface UserGenderReponse {
    id: number;
    initials: string;
    description: string;
}