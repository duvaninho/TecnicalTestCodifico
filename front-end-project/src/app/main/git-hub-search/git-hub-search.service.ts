import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "./models/user";

@Injectable({
  providedIn: 'root'
})
export class GitHubSearchService {

  constructor(private _httpClient:HttpClient) { }

  findGitHubUser(username:string):Observable<User> {
    return this._httpClient.get<User>(`https://api.github.com/users/${username}`);
  }
}
