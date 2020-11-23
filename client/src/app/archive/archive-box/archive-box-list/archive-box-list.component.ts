import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { ArchiveService } from '../../archive.service';
import { File } from '../../../models/file.model';
import { MatPaginator } from '@angular/material/paginator';
import { Box } from 'src/app/models/box.model';

@Component({
  selector: 'app-archive-box-list',
  templateUrl: './archive-box-list.component.html',
  styleUrls: ['./archive-box-list.component.css']
})
export class ArchiveBoxListComponent implements OnInit, AfterViewInit {
  displayedColumns = ['name', 'code', 'button']
  dataSource = this.service.boxesDataSource;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public service: ArchiveService) { }

  ngOnInit() {
    this.getAllBoxes();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  doFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  // hideValues () {
  //   this.dataSource.filteredData()
  // }
  

  populateForm(rd: File) {
    this.service.fileFormData = Object.assign({}, rd)
  }

  public getAllBoxes() {
    let resp = this.service.getBoxesForList();
    console.log(resp)
    resp.then(boxes => this.dataSource.data = boxes as Box[]);
  }

  onDelete(id) {
    if (confirm('Are you sure?')) {
      this.service.deleteBox(id)
        .subscribe(
          res => { this.service.getBoxesForList(); },
          err => {
            console.log(err);
          })
    }
  }
}
