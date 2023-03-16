import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  properties: Array<any> = [
    {
      "Id": 1,
      "Name": "Birla House",
      "Type": "House",
      "Price": 12000
    },
    {
      "Id": 2,
      "Name": "Erose House",
      "Type": "House",
      "Price": 19700
    },
    {
      "Id": 3,
      "Name": "Mer House",
      "Type": "House",
      "Price": 11400
    },
    {
      "Id": 4,
      "Name": "Angle House",
      "Type": "House",
      "Price": 13400
    },
    {
      "Id": 5,
      "Name": "Marco House",
      "Type": "House",
      "Price": 14300
    },
    {
      "Id": 6,
      "Name": "Pearl White House",
      "Type": "House",
      "Price": 18000
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
