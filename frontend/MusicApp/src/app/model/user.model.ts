import FavoriteMusic from "./favorite-music.model";

export default class User {
    public id?: String;
    public email?: String;
    public name?: String;
    public photo?: String;
    public favoriteMusics?: FavoriteMusic[];
}