import Music from "./music.model";

export default class Album {
    public id?: String;
    public name?: String;
    public description?: String;
    public backdrop?: String;
    public band?: String;
    public musics?:Music[];
}