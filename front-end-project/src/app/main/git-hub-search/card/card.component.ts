import {Component, Input, OnInit} from '@angular/core';
import {User} from "../models/user";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() user:User={
    login: "duvaninho",
    id: 39956513,
    avatar_url: "https://avatars.githubusercontent.com/u/39956513?v=4",
    name: "Duvan felipe",
    blog: "http://google.com.co",
    location: "Valledupar",
    twitter_username: "@duvaninho",
    public_repos: 5,
    followers: 0,
    following: 0,
    created_at: new Date("2018-06-05T13:24:23Z"),
  };
  constructor() { }

  ngOnInit(): void {
  }

}
