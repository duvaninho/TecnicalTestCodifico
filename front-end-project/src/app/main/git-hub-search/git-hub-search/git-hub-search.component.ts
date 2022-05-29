import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {User} from "../models/user";
import {GitHubSearchService} from "../git-hub-search.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-git-hub-search',
  templateUrl: './git-hub-search.component.html',
  styleUrls: ['./git-hub-search.component.scss'],
})
export class GitHubSearchComponent implements OnInit {
  searchForm: FormGroup;
  user: User;
  isSubmitting: boolean = false;
  readonly message: string = "No hay usuarios que cumplan con el criterio de búsqueda";

  constructor(private _formBuilder: FormBuilder, private _gitHubSearchService: GitHubSearchService,private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.searchForm = this.initForm();
  }

  private initForm() {
    return this._formBuilder.group({
      username: ['', Validators.required]
    })
  }

  findGitHubUser() {
    if (this.isSubmitting) return;
    if (this.searchForm.invalid) return;
    let username = this.searchForm.controls.username.value;
    this._gitHubSearchService.findGitHubUser(username).subscribe(response => {
      if (!response) return;
      this.user = response;
    }, error => {
      this.user = null;
      this.toastr.error(this.message)
    }, () => {
      this.isSubmitting = false;
    })
  }
}
