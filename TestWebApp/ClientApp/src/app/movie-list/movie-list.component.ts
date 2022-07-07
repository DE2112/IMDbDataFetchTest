import {Component, Input} from '@angular/core';
import {Movie} from "../../models/movie";

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {
  @Input() public movies: Movie[] = [];
  public movieListCols: number = 1;
}
