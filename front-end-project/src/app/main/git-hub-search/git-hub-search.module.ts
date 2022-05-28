import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { GitHubSearchComponent } from './git-hub-search/git-hub-search.component';



@NgModule({
    declarations: [CardComponent, GitHubSearchComponent],
    exports: [
        GitHubSearchComponent
    ],
    imports: [
        CommonModule
    ]
})
export class GitHubSearchModule { }
