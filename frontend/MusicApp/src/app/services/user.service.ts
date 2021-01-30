import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import User from 'app/model/user.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import Register from './payload/register';
import SignIn from './payload/SignIn';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public authenticate(payload: SignIn): Observable<User> {
    return this.http.post<User>(
      `${environment.baseUrl}user/authenticate`,
      payload
    )
  }

  public register(payload: Register): Observable<User> {
    return this.http.post<User>(`${environment.baseUrl}user/register`, payload);
  }

  public addMusicToFavorite(userId, musicId): Observable<User> {
    return this.http.post<User>(`${environment.baseUrl}user/${userId}/favorite-music/${musicId}`, null);
  }

  public removeMusicFromFavorite(userId, musicId): Observable<User> {
    return this.http.delete<User>(
        `${environment.baseUrl}user/${userId}/favorite-music/${musicId}`,
    );
  }

}
