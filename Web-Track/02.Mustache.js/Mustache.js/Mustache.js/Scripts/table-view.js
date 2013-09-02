/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />

var controls = controls || {};
(function (c) {
    tableView = Class.create({
        init: function (source, cols) {
            if (!(source instanceof Array)) {
                throw "The source of the table-view must be list";
            };
            this.source = source;
            this.cols = cols
        },
        render: function (template) {
            var tableElement = document.createElement("table");
            var row = document.createElement("tr");
            var maxCellsInRow = this.cols;
            var cellInRow = 0;
            for (var i = 0; i < this.source.length; i++) {
                var cellItem = document.createElement("td");

                var item = this.source[i];
                cellItem.innerHTML = template(item);
                row.appendChild(cellItem);

                cellInRow++;
                if (cellInRow == maxCellsInRow) {
                    cellInRow = 0;
                    tableElement.appendChild(row);
                    row = document.createElement("tr");
                }

                if ((i == this.source.length - 1) && row.length != 0) {
                    tableElement.appendChild(row);
                }
            }
            
            return tableElement.outerHTML;
        }
    });

    c.getTableView = function (source, rows) {
        return new tableView(source, rows);
    }
}(controls || {}));