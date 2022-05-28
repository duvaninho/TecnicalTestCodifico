import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {GitHubSearchModule} from "./main/git-hub-search/git-hub-search.module";

@NgModule({
  declarations: [
    AppComponent
  ],
    imports: [
        BrowserModule,
        GitHubSearchModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
