import {Component, Inject} from '@angular/core';
import { Movie } from "../../models/movie";
import { MatDialog } from "@angular/material/dialog";
import { MovieInfoModalComponent } from "../movie-info-modal/movie-info-modal.component";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent {
  public isLoading: boolean = false;
  public titleField: string = '';
  public errorMessage: string = '';

  constructor(public dialog: MatDialog, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  findMovie(): void {
    this.isLoading = true;
    this.errorMessage = '';
    console.log(this.baseUrl + `datafetch/${this.titleField.replace(' ', '+')}`);
    this.http.get<Movie>(this.baseUrl + `datafetch/${this.titleField.replace(' ', '+')}`)
      .subscribe( data => {
        this.isLoading = false;

        if (data.title) {
          this.dialog.open(MovieInfoModalComponent, { data: data });
        } else {
          this.errorMessage = "Nothing found";
        }
      });
  }

  resetErrorMessage() {
    this.errorMessage = '';
  }
}
