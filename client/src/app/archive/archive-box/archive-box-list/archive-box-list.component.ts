import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../../archive.service';
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-archive-box-list',
  templateUrl: './archive-box-list.component.html',
  styleUrls: ['./archive-box-list.component.css']
})
export class ArchiveBoxListComponent implements OnInit {
  update: string;
  selectedOption: Guid; 
  boxes: Observable<any>; 
  files : Observable<any>; 
  isAddingBox: boolean; 
  guid: Guid
  

  constructor(public service: ArchiveService) { 
      this.guid = Guid.create();
      
  }

  ngOnInit(): void {
    this.isAddingBox = false; 
    this.resetForm();
    this.files = this.service.getFilesForForm();
    this.boxes = this.service.getBoxes();
    

    this.service.boxFormData = {
      id: "" ,
      name: "",
      code: ""
    }
    console.log("I'm box form data id = " + this.service.boxFormData.id)
  }



  onSubmit(form: NgForm) {
    console.log(form.value)
      this.insertFile(form)
  }

  insertFile(form: NgForm) {
    console.log("I'm boxID = " + form.value.boxId)
    this.service.postFile().subscribe(
      res => {
        this.resetForm(form);
        this.service.getFiles();
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form?: NgForm) {
    console.log(this.guid)
    if (form != null)
      form.resetForm();

    this.service.fileFormData = {
      id: this.guid.toString(),
      name: "",
      code: "",
      value: 0,
      archiveBoxId: "" , 
      
    }
  }


  updateBox(event: any) {
    this.service.fileFormData.archiveBoxId = this.selectedOption.toString();
  }

  updateFile(form: NgForm) {
    this.service.putFileDetail().subscribe(
      res => {
        console.log("Update ok")
        this.resetForm(form);
        this.service.getFiles();
      },
      err => {
        console.log(err);
        
      }
    );
  }

  changeIsAddingBox(){
    this.isAddingBox = true; 
  }

  insertBox(boxForm: NgForm){
    this.isAddingBox = false; 
    this.service.postBox().subscribe(
      res => {
        console.log("Box Inserted")
        this.boxes = this.service.getBoxes();
      },
      err => {
        console.log(err);
      }
    );
  }


}
