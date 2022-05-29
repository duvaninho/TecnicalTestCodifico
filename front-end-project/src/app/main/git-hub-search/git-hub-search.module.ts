import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';
import {CardComponent} from './card/card.component';
import {GitHubSearchComponent} from './git-hub-search/git-hub-search.component';
import {ReactiveFormsModule} from "@angular/forms";
import {GitHubSearchService} from "./git-hub-search.service";
import {ToastrModule} from "ngx-toastr";
import { IsNullPipe } from './pipes/is-null.pipe';


@NgModule({
  declarations: [CardComponent, GitHubSearchComponent, IsNullPipe],
  exports: [
    GitHubSearchComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [DatePipe,GitHubSearchService]
})
export class GitHubSearchModule {
}
