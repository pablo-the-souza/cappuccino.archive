import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { ArchiveService } from '../../archive.service';
import { File } from '../../../models/file.model';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-archive-file-list',
  templateUrl: './archive-file-list.component.html',
  styleUrls: ['./archive-file-list.component.css']
})
export class ArchiveFileListComponent implements OnInit, AfterViewInit {
  displayedColumns = ['name', 'code']
  dataSource = this.service.dataSource;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public service: ArchiveService) { }

  ngOnInit() {
    this.getAllReports();
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

  public getAllReports() {
    let resp = this.service.getFiles();
    console.log(resp)
    resp.then(files => this.dataSource.data = files as File[]);
  }

  onDelete(id) {
    if (confirm('Are you sure?')) {
      this.service.deleteFileDetail(id)
        .subscribe(
          res => { this.service.getFiles(); },
          err => {
            console.log(err);
          })
    }
  }
}
