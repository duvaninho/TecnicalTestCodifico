import {NgModule} from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';
import {CardComponent} from './card/card.component';
import {GitHubSearchComponent} from './git-hub-search/git-hub-search.component';


@NgModule({
  declarations: [CardComponent, GitHubSearchComponent],
  exports: [
    GitHubSearchComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [DatePipe]
})
export class GitHubSearchModule {
}
