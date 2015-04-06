using System;
using AppKit;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;

namespace RaiseMan
{
    public class PeopleView : NSView
    {
		NSArray people;
		NSMutableDictionary attributes;
		nfloat lineHeight;
		CGRect pageRect;
		nuint totalLinesPerPage;
		nuint employeeLinesPerPage;
		nuint currentPage;
		nint numberOfPages;

        private PeopleView()
        {
        }

		public PeopleView(NSArray persons) : base(new CGRect(0, 0, 700, 700))
		{
			people = (NSArray)persons.Copy();
			// The attributes of the ttext to be printed
			attributes = new NSMutableDictionary();
			NSFont font = NSFont.FromFontName("Monaco", 12.0f);
			lineHeight = font.CapHeight * 1.7f;
			attributes.SetValueForKey(font, NSAttributedString.FontAttributeName);
		}

		public override bool KnowsPageRange(ref NSRange range)
		{
			NSPrintOperation po = NSPrintOperation.CurrentOperation;
			NSPrintInfo printInfo = po.PrintInfo;

			// Where can I draw?
			pageRect = printInfo.ImageablePageBounds;
			CGRect newFrame = CGRect.Empty;
			newFrame.Location = CGPoint.Empty;
			newFrame.Size = printInfo.PaperSize;
			this.Frame = newFrame;

			// How many lines per page?
			totalLinesPerPage = (nuint)Math.Floor(pageRect.Size.Height / lineHeight);
			employeeLinesPerPage = totalLinesPerPage -2;

			// Pages are 1-based
			range.Location = 1;

			// How many pages will it take?
			range.Length = (nint)people.Count/((nint)employeeLinesPerPage);
			if ((nuint)people.Count % employeeLinesPerPage > 0) {
				range.Length++;
			}
			numberOfPages = range.Length;
			Console.WriteLine("Number of pages: {0}", numberOfPages);
			return true;
		}

		public override CGRect RectForPage(nint pageNumber)
		{
			// Note the current page
			currentPage = (nuint)pageNumber-1;

			// Return the same page rect everytime
			return pageRect;
		}

		public override bool IsFlipped
		{
			get
			{
				return true;
			}
		}

		public override void DrawRect(CGRect dirtyRect)
		{
			CGRect nameRect = CGRect.Empty;
			CGRect raiseRect = CGRect.Empty;
			raiseRect.Size = nameRect.Size = new CGSize(0.0f, lineHeight);

			nameRect.Location = new CGPoint(pageRect.Location.X, nameRect.Location.X);
			nameRect.Size = new CGSize(200.0f, nameRect.Size.Height);
			raiseRect.Location = new CGPoint(nameRect.GetMaxX(), raiseRect.Location.Y);
			raiseRect.Size = new CGSize(100.0f, raiseRect.Size.Height);

			nuint emptyRows = 2;
			for (nuint i = 0; i < employeeLinesPerPage; i++) {
				nuint index = (currentPage * employeeLinesPerPage) + i;
				if (index >= people.Count) {
					emptyRows = totalLinesPerPage - i;
					break;
				}
				Person p = people.GetItem<Person>(index);

				// Draw index and name
				nameRect.Location = new CGPoint(nameRect.Location.X, pageRect.Location.Y + (i * lineHeight));
				NSString nameString = new NSString(String.Format("{0:D2}: {1}", index+1, p.Name));
				nameString.DrawInRect(nameRect, attributes);

				raiseRect.Location = new CGPoint(raiseRect.Location.X, nameRect.Location.Y);
				NSString raiseString = new NSString(String.Format("{0:P1}", p.ExpectedRaise));
				raiseString.DrawInRect(raiseRect, attributes);
			}
			NSString printPageNumber = new NSString(String.Format("Page {0}", currentPage + 1));
			printPageNumber.DrawInRect(new CGRect(nameRect.Location.X, nameRect.Location.Y + nameRect.Size.Height * emptyRows, 200.0f, nameRect.Size.Height), attributes);

		}
    }
}

